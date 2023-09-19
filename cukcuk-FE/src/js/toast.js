import { defineStore } from 'pinia';

export const useToast = defineStore('toast', {
    state: () => ({
        showToast: false,
        listToast: [],
    }),

    actions: {
        push(toast) {
            this.listToast.push(toast);
            const duration = 5000;
            //time out close toast
            toast.idTimeOut = setTimeout(() => {
                this.remove(toast);
            }, duration);
        },
        remove(toastRemove) {
            clearTimeout(toastRemove.idTimeOut);

            this.listToast = this.listToast.filter((toast) => toast.toastId !== toastRemove.toastId);
        },
    },
});