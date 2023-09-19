<template lang="">
    <div class="ntt-group-toast-message">
        <div v-for="(toast, index) in listToast" :key="index" :class="`toast toast-${toast.type}`">
            <div class="left-toast">
                <p class="i-toast center">
                    <MISAIcon class="icon-toast" :icon="toast.type"></MISAIcon>
                </p>
                <p class="toast-title">{{ toast.title }}</p>
                <p class="toast-text">{{ toast.content }}</p>
            </div>
            <div class="right-toast">
                <p class="toast-action">Hoàn tác</p>
                <button @click="removeToast(toast)" class="btn-close center close-dialog">
                    <img src="../../../assets/icon/close.svg" alt="" />
                </button>
            </div>
        </div>
    </div>
</template>
<script setup>
import { storeToRefs } from 'pinia';
import { useToast } from '../../../js/toast';
const toast = useToast();
const { listToast } = storeToRefs(toast);

const removeToast = (toastId) => {
    toast.remove(toastId);
};
</script>
