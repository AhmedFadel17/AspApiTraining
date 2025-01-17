import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';  // Use useNavigate instead of useHistory
import useSignIn from 'react-auth-kit/hooks/useSignIn';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import axios from 'axios';
import { Button, TextField, Typography, Container, Checkbox, FormControlLabel } from '@mui/material';

const Login = () => {
    const signIn = useSignIn();
  const navigate = useNavigate();  // Use useNavigate for navigation

  const [error, setError] = useState('');  // To display any login error

  // Form validation schema
  const validate = values => {
    const errors = {};
    if (!values.email) {
      errors.email = 'Email is required';
    } else if (!/\S+@\S+\.\S+/.test(values.email)) {
      errors.email = 'Invalid email address';
    }
    if (!values.password) {
      errors.password = 'Password is required';
    }
    return errors;
  };

  // Handle form submission
  const handleSubmit = async (values, { setSubmitting }) => {
    try {
      // Make the login request using Axios
      const response = await axios.post('https://your-api-url.com/login', {
        email: values.email,
        password: values.password,
      });

      // Check if login was successful
      if (response.data.token) {
        // Check if "Remember Me" is selected
        const expiresIn = values.rememberMe ? 86400 : 3600;  // 86400 seconds = 1 day, 3600 seconds = 1 hour

        // Sign in using React Auth Kit
        signIn({
          token: response.data.token,
          expiresIn: expiresIn,  // Set expiration time based on "Remember Me"
          tokenType: 'Bearer',
          authState: { email: values.email },
        });

        // Redirect to the dashboard after successful login
        navigate('/dashboard');  // Use navigate instead of history.push
      }
    } catch (error) {
      setError('Invalid email or password');
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <Container maxWidth="sm">
      <Typography variant="h4" gutterBottom>
        Login
      </Typography>
      {error && <Typography color="error">{error}</Typography>}
      <Formik
        initialValues={{ email: '', password: '', rememberMe: false }}
        validate={validate}
        onSubmit={handleSubmit}
      >
        {({ isSubmitting }) => (
          <Form>
            <div>
              <Field
                as={TextField}
                name="email"
                label="Email"
                variant="outlined"
                fullWidth
                margin="normal"
                type="email"
                helperText={<ErrorMessage name="email" />}
                error={!!<ErrorMessage name="email" />}
              />
            </div>
            <div>
              <Field
                as={TextField}
                name="password"
                label="Password"
                variant="outlined"
                fullWidth
                margin="normal"
                type="password"
                helperText={<ErrorMessage name="password" />}
                error={!!<ErrorMessage name="password" />}
              />
            </div>
            <div>
              <FormControlLabel
                control={
                  <Field
                    as={Checkbox}
                    name="rememberMe"
                    color="primary"
                  />
                }
                label="Remember Me"
              />
            </div>
            <div>
              <Button
                type="submit"
                variant="contained"
                color="primary"
                fullWidth
                disabled={isSubmitting}
              >
                Login
              </Button>
            </div>
          </Form>
        )}
      </Formik>
    </Container>
  );
};

export default Login;
