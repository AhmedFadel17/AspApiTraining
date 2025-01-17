import React from 'react';
import logo from './logo.svg';
import './App.css';
import { Routes, Route } from 'react-router-dom';
import Home from './pages/main/Home';
import Login from './pages/auth/Login';
import Register from './pages/auth/Register';
import Dashboard from './pages/dashboard/Home'
import MainLayout from './layouts/main';
function App() {
    return (

        <div className="App">
            <MainLayout>
                <Routes>
                    <Route path="/" element={
                        <Home />
                    } />
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} />
                    <Route path="/dashboard" element={<Dashboard />} />
                </Routes>
            </MainLayout>
        </div>

    );
}

export default App;
