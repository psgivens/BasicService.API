# BasicService
Basic service which demonstrates domain agnostic capabilities such as authentication, db connection, and the like. 



# Overview

## Work arounds

**Hot Reload** is broken (at least in Ubuntu 18.04) in the create-react-app setup. [Here](https://stackoverflow.com/questions/42189575/create-react-app-reload-not-working) is a fix.

    sudo echo 1048576 > /proc/sys/fs/inotify/max_user_watches


## Creating the react/redux app

Create the project

    npx create-react-app webapp --typescript
    cd webapp

Add dependencies    

    npm install --save "@types/d3"
    npm install --save "@types/react-redux"
    npm install --save "@types/react-router-dom"
    npm install --save "@types/reduce-reducers"
    npm install --save "@types/redux"
    npm install --save "@types/redux-saga"
    npm install --save "node-sass-chokidar"
    
    npm install --save redux react-redux

Add these scripts to package.json

      "build-css": "node-sass-chokidar --include-path ./src --include-path ./node_modules src/ -o src/",
      "watch-css": "npm run build-css && node-sass-chokidar --include-path ./src   --include-path ./node_modules src/ -o src/ --watch --recursive",

Create a values ./src/basic/valuesReducer.ts
    
    export type ValuesEvent = {
        type: "VALUES_FAILED"
    } | {
        type: "VALUES_SUCCESS_STRINGS"
        values: string[]
    }
    
    export function valuesReducers(state:string [] = [], action: ValuesEvent): string[] {
        return []
    }
    
Create an reducers aggregate in ./src/basic/index.ts

    import { combineReducers } from 'redux';
    import { valuesReducers } from './valuesReducers';
    
    export type All = {} & {
    }  
    
    export const initialState = (accessToken:string):All => ( { 
      values: []
    })
    
    export const reducers = combineReducers( {
      values: valuesReducers
      })

Add saga infrastructure to ./src/index.tsx

    import { Provider } from 'react-redux'
    import createSagaMiddleware from 'redux-saga'
    import { applyMiddleware, createStore, Store as ReduxStore } from 'redux'
    import { reducers } from './basic/reducers'
    import * as state from './basic/reducers'
    
    const sagaMiddleware = createSagaMiddleware()
    
    // You'll replace this with your sagas defined elsewhere
    function *fakeSaga(): Iterator<any> {
    }
    
    const initialState = {
        values: []
    }
    const store: ReduxStore<state.All> = createStore(reducers, initialState, applyMiddleware(sagaMiddleware))
    sagaMiddleware.run(fakeSaga)

    // Replacement for: ReactDOM.render(<App />, document.getElementById('root'));
    ReactDOM.render(
        <Provider store={store}><App /></Provider>,
        document.getElementById('root') as HTMLElement
      );



  