import React from "react";
import { DataTypeProvider, DataTypeProviderProps } from "@devexpress/dx-react-grid";
import { Grid, Table, TableColumnVisibility, TableHeaderRow } from "@devexpress/dx-react-grid-material-ui";
import { Button, Popconfirm } from "antd";
import { $employees, columns, deleteEmployee } from "../../models/employee";
import styled from "styled-components";
import { AddEmployee, showAddingEmployeeModal } from "./adding-modal";
import { useStore } from "effector-react";

const TableContainer = styled.div`
   margin: 50px, 5px;
   width: 50%;
`;

export const GridRoot = styled.div`
   display: grid !important;
`;

const tableColumnExtensions = [{ columnName: "edit", width: "25%" }];

export function EmployeeTable() {
   const employees = useStore($employees);

   function EditColumn(props: DataTypeProvider.ValueFormatterProps) {
      return (
         <div>
            <span>
               {/* <Button type="link" onClick={() => showEditEmployeeModal()}>
                  Редактировать
               </Button> */}
               <Popconfirm
                  title="Удаление сотрудника"
                  description="Вы действительно хотите удалить этого сотрудника?"
                  onConfirm={() => deleteEmployee(props.row.id)}
                  okText="Да"
                  cancelText="Нет"
               >
                  <Button type="link">Удалить</Button>
               </Popconfirm>
            </span>
         </div>
      );
   }

   function EditColumnProvider(providerProps: DataTypeProviderProps) {
      return <DataTypeProvider formatterComponent={EditColumn} {...providerProps} />;
   }

   return (
      <TableContainer>
         <h2 style={{ textAlign: "center" }}>Список сотрудников</h2>
         <Button type="primary" onClick={() => showAddingEmployeeModal()}>
            Добавить сотрудника
         </Button>
         <Button style={{ marginLeft: 10 }} type="primary" href="/api/employees/download">
            Скачать список в rar
         </Button>
         <AddEmployee />
         <Grid rootComponent={GridRoot} rows={employees} columns={columns}>
            <EditColumnProvider for={["edit"]}></EditColumnProvider>
            <Table columnExtensions={tableColumnExtensions} />
            <TableHeaderRow />
            <TableColumnVisibility hiddenColumnNames={["id"]} />
         </Grid>
      </TableContainer>
   );
}
