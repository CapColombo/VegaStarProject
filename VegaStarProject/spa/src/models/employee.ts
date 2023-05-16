import { AxiosError } from "axios";
import { createEffect, createEvent, createStore, forward } from "effector";
import { apiClient } from "./requests";
import { message } from "antd";

export const columns = [
   {
      name: "edit",
      title: "-",
   },
   {
      name: "id",
      title: "id",
   },
   {
      name: "fullName",
      title: "ФИО",
   },
   {
      name: "age",
      title: "Возраст",
   },
   {
      name: "experienceYears",
      title: "Стаж",
   },
   {
      name: "workplaceName",
      title: "Рабочее место",
   },
   {
      name: "computerNumber",
      title: "Номер компьютера",
   },
];

export type Employee = {
   id: string;
   fullName: string;
   age: number | null;
   experienceYears: number | null;
   workplaceName: string | null;
   computerNumber: number | null;
};

export type EmployeeAddDto = {
   fullName: string;
   age: number;
   experienceYears: number;
   workplaceId: string;
};

export const loadEmployees = createEvent();
export const createEmployee = createEvent<EmployeeAddDto>();
export const deleteEmployee = createEvent<string>();

const loadEmployeesFx = createEffect<void, Array<Employee>, AxiosError>().use(async () => {
   try {
      return await apiClient.get("/api/employees").then(({ data }) => data);
   } catch (e) {
      message.error({ content: "Ошибка сервера. Не удалось выполнить действие", duration: 3 });
   }
});

const createEmployeeFx = createEffect<EmployeeAddDto, void, AxiosError>().use(async (dto) => {
   try {
      return await apiClient.post("/api/employees/add-employee", dto);
   } catch (e) {
      message.error({ content: "Ошибка сервера. Не удалось выполнить действие", duration: 3 });
   }
});

const deleteEmployeeFx = createEffect<string, void, AxiosError>().use(async (id) => {
   try {
      await apiClient.delete(`/api/employees/${id}`);
   } catch (e) {
      message.error({ content: "Ошибка сервера. Не удалось выполнить действие", duration: 3 });
   }
});

export const $employees = createStore<Array<Employee>>([]).on(loadEmployeesFx.doneData, (_, data) => data);

forward({
   from: loadEmployees,
   to: loadEmployeesFx,
});

forward({
   from: createEmployee,
   to: createEmployeeFx,
});

forward({
   from: deleteEmployee,
   to: deleteEmployeeFx,
});

forward({
   from: [createEmployeeFx.done, deleteEmployeeFx.done],
   to: loadEmployeesFx,
});
