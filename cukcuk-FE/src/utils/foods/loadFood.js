import axios from "axios";
// lấy tất cả dữ liệu món ăn
export async function getAllFood() {
    try {
        let res = await axios.get('https://localhost:7123/api/v1/Foods')
        return res;
    } catch (error) {
        return error.response.status;
    }
}
// filter dữ liệu món ăn
export async function filterFood(listFilter, filterLimit, filterPage, filterSort) {
    try {
        let data = {
            Filters: listFilter,
            Limit: filterLimit,
            Page: filterPage,
            Sort: filterSort,
        }
        let res = await axios.post('https://localhost:7123/api/v1/Foods/filter', data)
        return res;
    } catch (error) {
        return error.response.status;
    }
}
// Thêm mã mới
export async function getNewCode(name) {
    try {
        let res = await axios.get(`https://localhost:7123/api/v1/Foods/new-code?name=${name}`)
        return res;
    } catch (error) {
        return error.response.status;
    }
}
// Tìm theo id
export async function getFoodByID(id) {
    try {
        let res = await axios.get(`https://localhost:7123/api/v1/Foods/${id}`)
        return res;
    } catch (error) {
        return error.response.status;
    }
}
// Check mã trùng
export async function checkDuplicateCode(id, code) {
    try {
        let res = await axios.get(`https://localhost:7123/api/v1/Foods/duplicate-code?foodID=${id}&foodCode=${code}`)
        return res;
    } catch (error) {
        return error.response.status;
    }
}

// Thêm mới hình ảnh
export async function GetImage(name) {
    try {
        let res = await fetch(`https://localhost:7123/api/v1/Foods/get-image/${name}`)
            .then(res => res.blob())
        return res;
    } catch (error) {
        return error;
    }
}