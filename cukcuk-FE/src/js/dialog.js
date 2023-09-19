import { defineStore } from 'pinia';

export const useDialog = defineStore('dialog', {
    state: () => ({
        isShow: false,
        title: '', //tiêu đề
        headerName: '', //tên tiêu đề
        titleCode: '', //mã tiêu đề
        titleName: '', //tên 
        titleDescription: '', //mô tả
        objectData: {}, // đối tượng nhận được
        hasCode: false, // có mã hay không
    }),

    actions: {
        toggleDialog() {
            this.isShow = !this.isShow;
        },
        open(dialog) {
            this.isShow = true;
            this.hasCode = dialog.hasCode;
            this.title = dialog.title;
            this.headerName = dialog.headerName;
            this.titleCode = dialog.titleCode;
            this.titleName = dialog.titleName;
            this.titleDescription = dialog.titleDescription;
        },
        close() {
            this.isShow = false;
            this.objectData = {};
            this.title = '';
            this.titleCode = '';
            this.titleName = '';
            this.titleDescription = '';
        },
        isCode() {
            this.hasCode = true;
        },
        setObjectData(data) {
            this.objectData = data;
        },
        setMethod(method) {
            this.method = method;
        },
    },
});