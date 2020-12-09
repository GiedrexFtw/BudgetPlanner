import React from 'react'
import { Redirect } from 'react-router-dom'

export const Authenticated = () => {
    if (jwt === undefined) {
        return <Redirect to='/login' />
    }
        
}
