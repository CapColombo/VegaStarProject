import * as React from "react";
import { createStore, createEvent, merge } from "effector";
import { useStore } from "effector-react";
import { Button, Form, Input, Modal, Select } from "antd";
import { Employee, EmployeeAddDto, createEmployee } from "../../models/employee";
import { $workplaces } from "../../models/workplace";

export const showAddingEmployeeModal = createEvent();
export const hideAddingEmployeeModal = createEvent();

const $isVisible = createStore(false)
   .on(showAddingEmployeeModal, () => true)
   .reset(hideAddingEmployeeModal);

export function AddEmployee() {
   const [form] = Form.useForm();
   const workplaces = useStore($workplaces);
   const workplacesOptions = workplaces.map((w) => {
      return { value: w.id, label: w.name };
   });

   const footer = [
      <Button
         key={"save"}
         type={"primary"}
         onClick={() => {
            form.validateFields().then(() => {
               hideAddingEmployeeModal();
               const dto: EmployeeAddDto = {
                  fullName: form.getFieldValue("fullName"),
                  age: form.getFieldValue("age"),
                  experienceYears: form.getFieldValue("experienceYears"),
                  workplaceId: form.getFieldValue("workplaceId"),
               };
               createEmployee(dto);
            });
         }}
      >
         Создать
      </Button>,
      <Button key={"cancel"} onClick={() => hideAddingEmployeeModal()}>
         Отменить
      </Button>,
   ];

   const isVisible = useStore($isVisible);

   if (isVisible) {
      return (
         <Modal open={true} centered={true} maskClosable={false} closable={false} title="Добавление сотрудника" footer={footer}>
            <Form
               form={form}
               name="addEmployee"
               labelCol={{ span: 8 }}
               wrapperCol={{ span: 16 }}
               style={{ maxWidth: 600 }}
               initialValues={{ remember: true }}
               autoComplete="off"
            >
               <Form.Item label="ФИО" name="fullName" rules={[{ required: true, message: "Введите ФИО" }]}>
                  <Input />
               </Form.Item>

               <Form.Item
                  label="Возвраст"
                  name="age"
                  rules={[{ pattern: new RegExp(/^[0-9]+$/), message: "Введите двузначное число" }]}
               >
                  <Input maxLength={2} />
               </Form.Item>

               <Form.Item
                  label="Стаж"
                  name="experienceYears"
                  rules={[{ pattern: new RegExp(/^[0-9]+$/), message: "Введите двузначное число" }]}
               >
                  <Input maxLength={2} />
               </Form.Item>

               <Form.Item label="Рабочее место" name="workplaceId">
                  <Select options={workplacesOptions} />
               </Form.Item>
            </Form>
         </Modal>
      );
   }

   return null;
}
