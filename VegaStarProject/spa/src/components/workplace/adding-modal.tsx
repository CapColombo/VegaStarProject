import * as React from "react";
import { createStore, createEvent, merge } from "effector";
import { useStore } from "effector-react";
import { Button, Form, Input, Modal, Select } from "antd";
import { WorkplaceAddDto, createWorkplace } from "../../models/workplace";

export const showAddingWorkplaceModal = createEvent();
export const hideAddingWorkplaceModal = createEvent();

const $isVisible = createStore(false)
   .on(showAddingWorkplaceModal, () => true)
   .reset(hideAddingWorkplaceModal);

export function AddWorkplace() {
   const [form] = Form.useForm();

   const footer = [
      <Button
         key={"save"}
         type={"primary"}
         onClick={() => {
            form.validateFields().then(() => {
               hideAddingWorkplaceModal();
               const dto: WorkplaceAddDto = {
                  name: form.getFieldValue("name"),
                  computerNumber: form.getFieldValue("computerNumber"),
               };
               createWorkplace(dto);
            });
         }}
      >
         Создать
      </Button>,
      <Button key={"cancel"} onClick={() => hideAddingWorkplaceModal()}>
         Отменить
      </Button>,
   ];

   const isVisible = useStore($isVisible);

   if (isVisible) {
      return (
         <Modal
            open={true}
            centered={true}
            maskClosable={false}
            closable={false}
            title="Добавление рабочего места"
            footer={footer}
         >
            <Form
               form={form}
               name="addWorkplace"
               labelCol={{ span: 8 }}
               wrapperCol={{ span: 16 }}
               style={{ maxWidth: 600 }}
               initialValues={{ remember: true }}
               autoComplete="off"
            >
               <Form.Item label="Наименование" name="name" rules={[{ required: true, message: "Введите наименование" }]}>
                  <Input />
               </Form.Item>

               <Form.Item
                  label="Номер компьютера"
                  name="computerNumber"
                  rules={[{ pattern: new RegExp(/^[0-9]+$/), message: "Введите число" }]}
               >
                  <Input />
               </Form.Item>
            </Form>
         </Modal>
      );
   }

   return null;
}
