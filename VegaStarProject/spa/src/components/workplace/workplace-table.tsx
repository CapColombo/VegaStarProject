import React from "react";
import { DataTypeProvider, DataTypeProviderProps } from "@devexpress/dx-react-grid";
import { Grid, Table, TableColumnVisibility, TableHeaderRow } from "@devexpress/dx-react-grid-material-ui";
import { Button, Popconfirm } from "antd";
import styled from "styled-components";
import { useStore } from "effector-react";
import { $workplaces, columns, deleteWorkplace } from "../../models/workplace";
import { AddWorkplace, showAddingWorkplaceModal } from "./adding-modal";

const TableContainer = styled.div`
   margin: 50px, 5px;
   width: 50%;
`;

export const GridRoot = styled.div`
   display: grid !important;
`;

const tableColumnExtensions = [{ columnName: "edit", width: "25%" }];

export function WorkplaceTable() {
   const workplaces = useStore($workplaces);

   function EditColumn(props: DataTypeProvider.ValueFormatterProps) {
      return (
         <div>
            <span>
               <Popconfirm
                  title="Удаление рабочего места"
                  description="Вы действительно хотите удалить это рабочее место?"
                  onConfirm={() => deleteWorkplace(props.row.id)}
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
         <h2 style={{ textAlign: "center" }}>Список рабочих мест</h2>
         <Button type="primary" onClick={() => showAddingWorkplaceModal()}>
            Добавить рабочее место
         </Button>
         <AddWorkplace />
         <Grid rootComponent={GridRoot} rows={workplaces} columns={columns}>
            <EditColumnProvider for={["edit"]}></EditColumnProvider>
            <Table columnExtensions={tableColumnExtensions} />
            <TableHeaderRow />
            <TableColumnVisibility hiddenColumnNames={["id"]} />
         </Grid>
      </TableContainer>
   );
}
