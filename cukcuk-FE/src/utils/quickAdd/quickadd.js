import axios from "axios";


// // Thêm mới nhóm thực đơn
// export async function InsertMenuGroup(menugroup) {
//     let res = await axios.post('https://localhost:7123/api/v1/MenuGroups', menugroup)
//     return res;
// }


// // Thêm mới đơn vị tính
// export async function InsertUnit(foodUnit) {
//     let res = await axios.post('https://localhost:7123/api/v1/FoodUnits', foodUnit)
//     return res;
// }


// // Thêm nơi nấu
// export async function InsertCookPlace(cookPlace) {
//     let res = await axios.post('https://localhost:7123/api/v1/CookRooms', cookPlace)
//     return res;
// }


// Thêm mới thực đơn

export async function InsertAsync(objectData, objectName) {
    let res = await axios.post(`https://localhost:7123/api/v1/${objectName}`, objectData)
    return res;
}


// lấy tất cả danh sách
export async function getAllQuickAdd(objectName) {
    try {
        let res = await axios.get(`https://localhost:7123/api/v1/${objectName}`)
        return res;
    } catch (error) {
        return error.response.status;
    }
}