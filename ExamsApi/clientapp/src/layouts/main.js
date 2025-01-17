import React from 'react';
import Navbar from './../components/main/Navbar';  // Import Navbar component
import Footer from './../components/shared/Footer';  // Import Footer component
import { Container } from '@mui/material';  // MUI Container for content

const MainLayout = ({ children }) => {
  return (
    <div>
      <Navbar />  {/* Navbar at the top */}
      <Container
        sx={{
          paddingTop: '20px',
          paddingBottom: '20px',
          minHeight: 'calc(100vh - 160px)', // Ensures the content area takes up the remaining space
        }}
      >
        {children}  {/* Main content goes here */}
      </Container>
      <Footer />  {/* Footer at the bottom */}
    </div>
  );
};

export default MainLayout;
