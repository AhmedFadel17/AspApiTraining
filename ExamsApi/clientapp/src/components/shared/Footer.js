import React from 'react';
import { Box, Container, Typography, Link, Grid } from '@mui/material';

const Footer = () => {
  return (
    <Box
      component="footer"
      sx={{
        backgroundColor: '#282c34',
        color: 'white',
        padding: '20px 0',
        marginTop: 'auto',
      }}
    >
      <Container>
        <Grid container spacing={2} justifyContent="center">
          <Grid item xs={12} sm={4}>
            <Typography variant="h6" gutterBottom>
              My App
            </Typography>
            <Typography variant="body2">
              © {new Date().getFullYear()} My App. All rights reserved.
            </Typography>
          </Grid>

          <Grid item xs={12} sm={4}>
            <Typography variant="h6" gutterBottom>
              Quick Links
            </Typography>
            <ul style={{ listStyleType: 'none', paddingLeft: 0 }}>
              <li>
                <Link href="/" color="inherit" variant="body2">
                  Home
                </Link>
              </li>
              <li>
                <Link href="/login" color="inherit" variant="body2">
                  Login
                </Link>
              </li>
              <li>
                <Link href="/register" color="inherit" variant="body2">
                  Register
                </Link>
              </li>
              <li>
                <Link href="/dashboard" color="inherit" variant="body2">
                  Dashboard
                </Link>
              </li>
            </ul>
          </Grid>

          <Grid item xs={12} sm={4}>
            <Typography variant="h6" gutterBottom>
              Follow Us
            </Typography>
            <ul style={{ listStyleType: 'none', paddingLeft: 0 }}>
              <li>
                <Link href="#" color="inherit" variant="body2">
                  Facebook
                </Link>
              </li>
              <li>
                <Link href="#" color="inherit" variant="body2">
                  Twitter
                </Link>
              </li>
              <li>
                <Link href="#" color="inherit" variant="body2">
                  Instagram
                </Link>
              </li>
            </ul>
          </Grid>
        </Grid>
      </Container>
    </Box>
  );
};

export default Footer;
