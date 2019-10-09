import { combineReducers } from 'redux';
import { counterReducers } from './counterReducers';
import { valuesReducers } from './valuesReducers';

export type All = {} & {
  counter: number
  values: string []
}  

export const initialState =  { 
  counter: 0,
  values: []
}

export const reducers = combineReducers( {
  counter: counterReducers,
  values: valuesReducers
  })
  
  