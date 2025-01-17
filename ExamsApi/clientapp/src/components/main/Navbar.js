import React from 'react';
import { AppBar, Toolbar, Typography, Button, Container, useMediaQuery, Drawer, List, ListItem, ListItemText } from '@mui/material';
import { Link } from 'react-router-dom';
import MenuIcon from '@mui/icons-material/Menu';

const Navbar = () => {
  const [openDrawer, setOpenDrawer] = React.useState(false);
  const isMobile = useMediaQuery('(max-width:600px)');  // Detect mobile screen size

  const toggleDrawer = () => {
    setOpenDrawer(!openDrawer);
  };

  const menuItems = [
    { text: 'Home', path: '/' },
    { text: 'Login', path: '/login' },
    { text: 'Register', path: '/register' },
    { text: 'Dashboard', path: '/dashboard' },
  ];

  return (
    <AppBar position="sticky" color="primary">
      <Toolbar>
        <Typography variant="h6" sx={{ flexGrow: 1 }}>
          My App
        </Typography>

        {/* Desktop Navigation */}
        {!isMobile && (
          <Container sx={{ display: 'flex', justifyContent: 'flex-end' }}>
            {menuItems.map((item) => (
              <Button key={item.text} color="inherit" component={Link} to={item.path} sx={{ marginLeft: 2 }}>
                {item.text}
              </Button>
            ))}
          </Container>
        )}

        {/* Mobile Navigation */}
        {isMobile && (
          <>
            <Button color="inherit" onClick={toggleDrawer}>
              <MenuIcon />
            </Button>
            <Drawer anchor="right" open={openDrawer} onClose={toggleDrawer}>
              <List>
                {menuItems.map((item) => (
                  <ListItem button key={item.text} component={Link} to={item.path} onClick={toggleDrawer}>
                    <ListItemText primary={item.text} />
                  </ListItem>
                ))}
              </List>
            </Drawer>
          </>
        )}
      </Toolbar>
    </AppBar>
  );
};

export default Navbar;
