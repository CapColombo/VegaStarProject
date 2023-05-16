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
      name: "name",
      title: "Наименование",
   },
   {
      name: "computerNumber",
      title: "Номер компьютера",
   },
];

export type Workplace = {
   id: string;
   name: string;
   computerNumber: number | null;
};

export type WorkplaceAddDto = {
   name: string;
   computerNumber: number | null;
};

export const loadWorkplaces = createEvent();
export const createWorkplace = createEvent<WorkplaceAddDto>();
export const deleteWorkplace = createEvent<string>();

const loadWorkplacesFx = createEffect<void, Array<Workplace>, AxiosError>().use(async () => {
   try {
      return await apiClient.get("/api/workplaces").then(({ data }) => data);
   } catch (e) {
      message.error({ content: "Ошибка сервера. Не удалось выполнить действие", duration: 3 });
   }
});

const createWorkplaceFx = createEffect<WorkplaceAddDto, void, AxiosError>().use(async (dto) => {
   try {
      return await apiClient.post("/api/workplaces/add-workplace", dto);
   } catch (e) {
      message.error({ content: "Ошибка сервера. Не удалось выполнить действие", duration: 3 });
   }
});

const deleteWorkplaceFx = createEffect<string, void, AxiosError>().use(async (id) => {
   try {
      await apiClient.delete(`/api/workplaces/${id}`);
   } catch (e) {
      message.error({ content: "Ошибка сервера. Не удалось выполнить действие", duration: 3 });
   }
});

export const $workplaces = createStore<Array<Workplace>>([]).on(loadWorkplacesFx.doneData, (_, data) => data);

forward({
   from: loadWorkplaces,
   to: loadWorkplacesFx,
});

forward({
   from: createWorkplace,
   to: createWorkplaceFx,
});

forward({
   from: deleteWorkplace,
   to: deleteWorkplaceFx,
});

forward({
   from: [createWorkplaceFx.done, deleteWorkplaceFx.done],
   to: loadWorkplacesFx,
});
