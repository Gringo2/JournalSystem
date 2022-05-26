import { createStore, combineReducers, applyMiddleware } from 'redux'
import thunk from 'redux-thunk'
import { composeWithDevTools } from 'redux-devtools-extension'
import { disciplineListReducer, disciplineDetailsReducer } from './Reducers/disciplineReducers'

const reducer = combineReducers({
    disciplineList: disciplineListReducer,
    disciplineDetails: disciplineDetailsReducer,
})


const initialstate = {}

const middleware = [thunk]

const store = createStore(reducer, initialstate, 
    composeWithDevTools(applyMiddleware(...middleware)))

export default store    