import { 
    DISCIPLINE_LIST_REQUEST,
    DISCIPLINE_LIST_SUCCESS,
    DISCIPLINE_LIST_FAIL,

    DISCIPLINE_DETAILS_REQUEST,
    DISCIPLINE_DETAILS_SUCCESS,
    DISCIPLINE_DETAILS_FAIL,

 } from '../constants/disciplineConstants'



export const disciplineListReducer =(state = { disciplines: [] }, action) => {
    switch (action.type) {
        case DISCIPLINE_LIST_REQUEST:
            return { loading: true, disciplines: [] }
        
        case DISCIPLINE_LIST_SUCCESS:
            return { loading: false, disciplines: action.payload }

        case DISCIPLINE_LIST_FAIL:
            return { loading: false, error: action.payload }    


        default:
            return state



    }
}


export const disciplineDetailsReducer =(state = { discipline: [] }, action) => {
    switch (action.type) {
        case DISCIPLINE_DETAILS_REQUEST:
            return { loading: true, discipline: [] }
        
        case DISCIPLINE_DETAILS_SUCCESS:
           return { loading: false, discipline: action.payload }
        case DISCIPLINE_DETAILS_FAIL:
            return { loading: false, error: action.payload }    


        default:
            return state



    }
}
