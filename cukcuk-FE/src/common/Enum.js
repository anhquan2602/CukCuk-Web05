/**
 * Các toán tử dùng để lọc 
 * author: NA Quân(25/08/2023)
 */
export const operators = {
    CONTAIN: 0,
    EQUAL: 1,
    START_WITH: 2,
    END_WITH: 3,
    NOT_CONTAIN: 4,
    LESS: 5,
    BIGGER: 6,
    LESS_OR_EQUAL: 7,
    BIGGER_OR_EQUAL: 8
}

/**
 * Sắp xếp 
 * author: NA Quân(25/08/2023)
 */
export const orderBy = {
    ASC: 0,
    DESC: 1,
    NONE: 2
}

/**
 * Kiểu form
 * author: NA Quân(25/08/2023)
 */
export const formMode = {
    add: 1,
    update: 2,
    clone: 3,
}

// Kiểu popup hiển thị
// CreatedBy: NA Quân(03/03/2023)
export const typePopup = {
    delete: 1,
    validate: 2,
    store: 3,
    multipleDelete: 4,
    duplicate: 5,
    errorImg: 6,
    errorDuplicateService: 7,
    errors: 8,
}


// Kiểu popup add
export const typePopupAdd = {
    addUnit: 1,
    addGroupMenu: 2,
    addCookPlace: 3,
}