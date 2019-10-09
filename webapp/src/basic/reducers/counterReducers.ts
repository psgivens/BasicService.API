import { CounterEvent } from '../actions/CounterSaga'

export function counterReducers(state:number=0, action: CounterEvent): number {
    return state + 1
}

    // switch(action.type) {
    //   case "VALUES_SUCCESS_STRINGS":
    //     return action.values
    //   case "VALUES_FAILED":
    //     return []
    //   default:
    //     return state
    // }

  