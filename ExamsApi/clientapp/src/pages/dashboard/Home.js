import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Grid, Card, CardContent, Typography, CircularProgress, Button, Box } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import useAuthHeader from 'react-auth-kit/hooks/useAuthHeader';
const DashboardHome = () => {
  const [exams, setExams] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();
  const authHeader = useAuthHeader(); // Get the auth header function

  useEffect(() => {
    const fetchExams = async () => {
      try {
        const response = await axios.get('/api/exams', {
          headers: {
            Authorization: authHeader, // Use the auth header function
          },
        });
        setExams(response.data);
      } catch (error) {
        console.error('Error fetching exams:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchExams();
  }, []);

  const handleAddExam = () => {
    navigate('/add-exam'); // Navigate to the "Add Exam" page
  };

  if (loading) {
    return <CircularProgress />;
  }

  return (
    <Box sx={{ padding: 3 }}>
      <Box sx={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: 3 }}>
        <Typography variant="h4">Exams</Typography>
        <Button variant="contained" color="primary" onClick={handleAddExam}>
          Add New Exam
        </Button>
      </Box>

      <Grid container spacing={3}>
        {exams.map((exam) => (
          <Grid item xs={12} sm={6} key={exam.id}>
            <Card>
              <CardContent>
                <Typography variant="h6" gutterBottom>
                  {exam.title}
                </Typography>
                <Typography variant="body2" color="textSecondary">
                  {exam.description}
                </Typography>
                <Typography variant="body2" color="textSecondary">
                  Date: {exam.date}
                </Typography>
              </CardContent>
            </Card>
          </Grid>
        ))}
      </Grid>
    </Box>
  );
};

export default DashboardHome;
