import React from 'react';
import { Cookies } from 'react-cookie';
import { Route, Redirect } from "react-router-dom";

export const GuardedRoute = ({ component: Component, ...rest }) => (
    <Route {...rest} render={(props) => (
        typeof (new Cookies().get("access_token")) !== "undefined"
            ? <Component {...props} />
            : <Redirect to='/login' />
    )} />
)