import React from "react";
import ReactDOM from "react-dom/client";
import { App } from "./App";
import { loadEmployees } from "./models/employee";
import { loadWorkplaces } from "./models/workplace";

const root = ReactDOM.createRoot(document.getElementById("root") as HTMLElement);
loadEmployees();
loadWorkplaces();
root.render(
   <React.StrictMode>
      <App />
   </React.StrictMode>
);
