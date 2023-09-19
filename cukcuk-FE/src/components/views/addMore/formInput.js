export const inputFormUnit = [{
        field: 'FoodUnitName',
        type: 'input',
        rules: 'required',
        label: 'Tên đơn vị tính',

    },
    {
        field: 'FoodUnitDescription',
        type: 'textarea',
        label: 'Mô tả',

    }
]

export const inputFormGroupMenu = [{
        field: 'MenuGroupCode',
        type: 'input',
        label: 'Mã nhóm thực đơn',
    },
    {
        field: 'MenuGroupName',
        type: 'input',
        rules: 'required',
        label: 'Tên nhóm thực đơn',
    },
    {
        field: 'MenuGroupDescription',
        type: 'textarea',
        label: 'Mô tả',
    }
]

export const inputFormCookPlace = [{
        field: 'CookRoomName',
        type: 'input',
        rules: 'required',
        label: 'Tên nơi nấu',
    },
    {
        field: 'CookRoomDescription',
        type: 'textarea',
        label: 'Mô tả',
    }
]