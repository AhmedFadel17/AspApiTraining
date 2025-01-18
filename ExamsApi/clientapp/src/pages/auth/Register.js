import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';  // Use useNavigate instead of useHistory
import useSignIn from 'react-auth-kit/hooks/useSignIn';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import axios from 'axios';
import { Button, TextField, Typography, Container } from '@mui/material';
import Swal from 'sweetalert2'

const Register = () => {
    const signIn = useSignIn();
  const navigate = useNavigate();  // Use useNavigate for navigation

  const [error, setError] = useState('');  // To display any registration error

  // Form validation schema
  const validate = values => {
    const errors = {};
    if (!values.firstName) {
      errors.firstName = 'First Name is required';
    }
    if (!values.lastName) {
      errors.lastName = 'Last Name is required';
    }
    if (!values.email) {
      errors.email = 'Email is required';
    } else if (!/\S+@\S+\.\S+/.test(values.email)) {
      errors.email = 'Invalid email address';
    }
    if (!values.username) {
      errors.username = 'Username is required';
    }
    if (!values.password) {
      errors.password = 'Password is required';
    } else if (values.password.length < 6) {
      errors.password = 'Password must be at least 6 characters';
    }
    if (values.password !== values.passwordConfirmation) {
      errors.passwordConfirmation = 'Passwords must match';
    }
    return errors;
  };

  // Handle form submission
  const handleSubmit = async (values, { setSubmitting }) => {
    try {
      // Make the registration request using Axios
      const response = await axios.post('/api/auth/register', {
        firstName: values.firstName,
        lastName: values.lastName,
        email: values.email,
        username: values.username,
        password: values.password,
      });

      // If registration is successful, sign in the user
      if (response) {
        Swal.fire({
          title: 'Registration Successful!',
          text: 'You have successfully registered. Click the button below to login.',
          icon: 'success',
          confirmButtonText: 'Login Now',
          allowOutsideClick: false,
          allowEscapeKey: false,
        }).then((result) => {
          if (result.isConfirmed) {
            navigate('/login'); // Navigate to the login page
          }
        });
      }
    } catch (error) {
      setError('Registration failed. Please try again.');
    } finally {
      setSubmitting(false);
    }
  };

  return (
    <Container maxWidth="sm">
      <Typography variant="h4" gutterBottom>
        Register
      </Typography>
      {error && <Typography color="error">{error}</Typography>}
      <Formik
        initialValues={{
          firstName: '',
          lastName: '',
          email: '',
          username: '',
          password: '',
          passwordConfirmation: '',
        }}
        validate={validate}
        onSubmit={handleSubmit}
      >
        {({ isSubmitting }) => (
          <Form>
            <div>
              <Field
                as={TextField}
                name="firstName"
                label="First Name"
                variant="outlined"
                fullWidth
                margin="normal"
                helperText={<ErrorMessage name="firstName" />}
                error={!!<ErrorMessage name="firstName" />}
              />
            </div>
            <div>
              <Field
                as={TextField}
                name="lastName"
                label="Last Name"
                variant="outlined"
                fullWidth
                margin="normal"
                helperText={<ErrorMessage name="lastName" />}
                error={!!<ErrorMessage name="lastName" />}
              />
            </div>
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
                name="username"
                label="Username"
                variant="outlined"
                fullWidth
                margin="normal"
                helperText={<ErrorMessage name="username" />}
                error={!!<ErrorMessage name="username" />}
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
              <Field
                as={TextField}
                name="passwordConfirmation"
                label="Confirm Password"
                variant="outlined"
                fullWidth
                margin="normal"
                type="password"
                helperText={<ErrorMessage name="passwordConfirmation" />}
                error={!!<ErrorMessage name="passwordConfirmation" />}
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
                Register
              </Button>
            </div>
          </Form>
        )}
      </Formik>
    </Container>
  );
};

export default Register;
