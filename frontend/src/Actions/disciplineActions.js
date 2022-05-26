import axios from 'axios'
import { 
    DISCIPLINE_LIST_REQUEST,
    DISCIPLINE_LIST_SUCCESS,
    DISCIPLINE_LIST_FAIL,

    DISCIPLINE_DETAILS_REQUEST,
    DISCIPLINE_DETAILS_SUCCESS,
    DISCIPLINE_DETAILS_FAIL,
 } from '../constants/disciplineConstants'



export const listDisciplines = () => async (dispatch) => {
    try {
        dispatch ({ type: DISCIPLINE_LIST_REQUEST})
 
        const { data } = await axios.get('/api/disciplines/')

        dispatch({
            type: DISCIPLINE_LIST_SUCCESS,
            payload: data
        })

    } catch (error) {
        dispatch({
            type:DISCIPLINE_LIST_FAIL,
            payload:error.response && error.response.data.detail
                ? error.response.data.detail
                : error.message,
        })

    }
} 

export const listDisciplineDetails = (id) => async (dispatch) => {
    try {
        dispatch ({ type: DISCIPLINE_DETAILS_REQUEST})
 
        const { data } = await axios.get(`/api/discipline/${id}`)

        dispatch({
            type: DISCIPLINE_DETAILS_SUCCESS,
            payload: data
        })

    } catch (error) {
        dispatch({
            type:DISCIPLINE_DETAILS_FAIL,
            payload:error.response && error.response.data.detail
                ? error.response.data.detail
                : error.message,
        })

    }
} 

