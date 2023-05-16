import React from "react";
import { Tabs, TabsProps } from "antd";
import { EmployeeTable } from "./components/employee/employee-table";
import { WorkplaceTable } from "./components/workplace/workplace-table";

export function App() {
   const items: TabsProps["items"] = [
      {
         key: "1",
         label: `Сотрудники`,
         children: <EmployeeTable />,
      },
      {
         key: "2",
         label: `Рабочие места`,
         children: <WorkplaceTable />,
      },
   ];

   return (
      <div>
         <Tabs defaultActiveKey="1" items={items} />
      </div>
   );
}
