<template>
  <div class="wrap-popup-add" v-if="isShow">
    <div class="ms-popup-add">
      <div class="header-popup-add">
        <div class="title-popup-add">{{ headerName }}</div>
        <div
          class="popup__header--close icon-form-close icon-16"
          title="Đóng"
          @click="handleClose()"
        ></div>
      </div>
      <div class="main-popup-add">
        <div
          class="input-add"
          v-for="(item, index) in setInputFrom"
          :key="index"
        >
          <div class="title-input-add">
            {{ item.label }}
            <span v-if="item?.rules === 'required'" style="color: red"
              >(*)</span
            >
          </div>
          <div class="input-add-value">
            <input
              v-if="item.type === 'input'"
              v-model="inputObject[item.field]"
            />
            <textarea
              v-if="item.type === 'textarea'"
              v-model="inputObject[item.field]"
            />
          </div>
        </div>
      </div>
      <div class="function-popup-add">
        <div class="wrap-function">
          <div class="popup__body-footer-right flex flex-items-center">
            <button
              class="btn-icons flex flex-items-center"
              title="Ctrl + L"
              tabindex="13"
              @click="dialog.setMethod(quickAdd())"
            >
              <div class="btn-icon icon-toolbar icon-16 icon-form-store"></div>
              <div class="btn-icon-text">Cất</div>
            </button>
            <button
              title="Esc"
              class="btn-icons flex flex-items-center"
              tabindex="15"
              @click="handleClose()"
            >
              <div class="btn-icon icon-toolbar icon-16 icon-form-cancel"></div>
              <div class="btn-icon-text">Huỷ bỏ</div>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
  <TheLoading :isLoading="isLoading" />
</template>
<script setup>
// eslint-disable-next-line
/* eslint-disable */
import {
  InsertAsync,
  getAllQuickAdd,
} from "../../../utils/quickAdd/quickadd.js";
import TheLoading from "@/components/base/Loading/TheLoading.vue";
import { storeToRefs } from "pinia";
import { computed, ref } from "vue";
import { useDialog } from "../../../js/dialog";
import {
  inputFormUnit,
  inputFormCookPlace,
  inputFormGroupMenu,
} from "./formInput.js";
const dialog = useDialog();
const { isShow, title, headerName } = storeToRefs(dialog);
const emit = defineEmits(["handleReloadData"]);
const isLoading = ref(false);
let inputForm = ref([]);
const foodUnitName = ref("");
let inputObject = ref({});
const handleClose = () => {
  inputObject.value = {};
  dialog.close();
};

// computed check tên
const setInputFrom = computed({
  get() {
    if (dialog.title === "CookRooms") {
      inputForm = inputFormCookPlace;
      console.log(inputFormCookPlace);
    } else if (dialog.title === "MenuGroups") {
      inputForm = inputFormGroupMenu;
    } else if (dialog.title === "FoodUnits") {
      inputForm = inputFormUnit;
    }
    return inputForm;
  },
});

// hàm cất dữ liệu vào database
const quickAdd = async () => {
  await InsertAsync(inputObject.value, dialog.title);
  isLoading.value = true;
  await emit("handleReloadData", dialog.title);
  isLoading.value = false;
  inputObject.value = {};
  dialog.close();
};
</script>