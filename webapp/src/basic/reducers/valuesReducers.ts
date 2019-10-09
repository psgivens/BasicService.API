
export type ValuesEvent = {
    type: "VALUES_FAILED"
} | {
    type: "VALUES_SUCCESS_STRINGS"
    values: string[]
}

export function valuesReducers(state:string [] = [], action: ValuesEvent): string[] {
    return []
}

    // switch(action.type) {
    //   case "VALUES_SUCCESS_STRINGS":
    //     return action.values
    //   case "VALUES_FAILED":
    //     return []
    //   default:
    //     return state
    // }

  