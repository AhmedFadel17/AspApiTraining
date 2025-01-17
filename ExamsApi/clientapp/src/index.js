import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import AuthProvider from 'react-auth-kit';
import createStore from 'react-auth-kit/createStore';
import { BrowserRouter } from "react-router-dom";


const root = ReactDOM.createRoot(document.getElementById('root'));
const store = createStore({
    authName: '_auth',
    authType: 'cookie',
    cookieDomain: window.location.hostname,
    cookieSecure: window.location.protocol === 'https:',
    // refresh: refresh
});
root.render(
    <React.StrictMode>
        <BrowserRouter>
            <AuthProvider store={store}>
                <App />
            </AuthProvider>
        </BrowserRouter>
  </React.StrictMode>
);

