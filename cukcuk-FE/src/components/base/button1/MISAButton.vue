<template>
    <button
        @mouseup="handleMouseUp"
        ref="myButton"
        class="btn-base"
        :class="['btn-' + props.type, { disable: props.disable }, props.class ? props.class : '']"
    >
    <p class="center">
            <template v-if="props.type === 'icon' || props.type === 'i-pri' || props.type === 'default' || props.type === 'footer'">
                <span class="center"> <slot name="icon"></slot></span>
            </template>

            {{ props.action }}
        </p>
    </button>
</template>
<script setup>
import { ref} from 'vue';
const props = defineProps({
    type: { type: String, default: '' }, //loại button: sec, pri, danger, icon, link
    action: { type: String, default: '' }, //Hành động chữ trong button
    disable: { type: Boolean, default: false }, //disable
    class: { type: String, default: '' }, //class của button
});
const myButton = ref(null);

const handleMouseUp = () => {
    myButton.value.blur();
};

</script>
