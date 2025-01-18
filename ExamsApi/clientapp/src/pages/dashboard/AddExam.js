import React from "react";
import { useFormik } from "formik";
import * as Yup from "yup";
import axios from "axios";
import Swal from "sweetalert2";
import useAuthHeader from 'react-auth-kit/hooks/useAuthHeader';

const AddExam = () => {
    const authHeader = useAuthHeader(); // Get the auth header function

  const formik = useFormik({
    initialValues: {
      name: "",
      description: "",
      grade: "",
      subject: "",
      time: "",
      totalMarks: "",
    },
    validationSchema: Yup.object({
      name: Yup.string()
        .max(255, "Name must be 255 characters or less")
        .required("Name is required"),
      description: Yup.string()
        .max(455, "Description must be 455 characters or less")
        .required("Description is required"),
      grade: Yup.number()
        .min(1, "Grade must be at least 1")
        .max(1000, "Grade must be 1000 or less")
        .required("Grade is required"),
      subject: Yup.string()
        .max(255, "Subject must be 255 characters or less")
        .required("Subject is required"),
      time: Yup.number()
        .min(0, "Time must be at least 0")
        .max(2500, "Time must be 2500 or less")
        .required("Time is required"),
      totalMarks: Yup.number()
        .min(0, "Total Marks must be at least 0")
        .max(1000, "Total Marks must be 1000 or less")
        .required("Total Marks is required"),
    }),
    onSubmit: async (values, { resetForm }) => {
      try {
        // Submit the form data
        const response = await axios.post("/api/exams", values,{headers: {
            Authorization: authHeader, // Use the auth header function
          }},);
        if (response.status === 200) {
          Swal.fire({
            title: "Success!",
            text: "Exam added successfully!",
            icon: "success",
          });
          resetForm();
        }
      } catch (error) {
        Swal.fire({
          title: "Error!",
          text: "Failed to add exam. Please try again.",
          icon: "error",
        });
      }
    },
  });

  return (
    <div style={{ maxWidth: "600px", margin: "auto", padding: "20px" }}>
      <h2>Add Exam</h2>
      <form onSubmit={formik.handleSubmit}>
        <div>
          <label htmlFor="name">Name</label>
          <input
            id="name"
            name="name"
            type="text"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.name}
          />
          {formik.touched.name && formik.errors.name ? (
            <div style={{ color: "red" }}>{formik.errors.name}</div>
          ) : null}
        </div>

        <div>
          <label htmlFor="description">Description</label>
          <textarea
            id="description"
            name="description"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.description}
          />
          {formik.touched.description && formik.errors.description ? (
            <div style={{ color: "red" }}>{formik.errors.description}</div>
          ) : null}
        </div>

        <div>
          <label htmlFor="grade">Grade</label>
          <input
            id="grade"
            name="grade"
            type="number"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.grade}
          />
          {formik.touched.grade && formik.errors.grade ? (
            <div style={{ color: "red" }}>{formik.errors.grade}</div>
          ) : null}
        </div>

        <div>
          <label htmlFor="subject">Subject</label>
          <input
            id="subject"
            name="subject"
            type="text"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.subject}
          />
          {formik.touched.subject && formik.errors.subject ? (
            <div style={{ color: "red" }}>{formik.errors.subject}</div>
          ) : null}
        </div>

        <div>
          <label htmlFor="time">Time (in minutes)</label>
          <input
            id="time"
            name="time"
            type="number"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.time}
          />
          {formik.touched.time && formik.errors.time ? (
            <div style={{ color: "red" }}>{formik.errors.time}</div>
          ) : null}
        </div>

        <div>
          <label htmlFor="totalMarks">Total Marks</label>
          <input
            id="totalMarks"
            name="totalMarks"
            type="number"
            onChange={formik.handleChange}
            onBlur={formik.handleBlur}
            value={formik.values.totalMarks}
          />
          {formik.touched.totalMarks && formik.errors.totalMarks ? (
            <div style={{ color: "red" }}>{formik.errors.totalMarks}</div>
          ) : null}
        </div>

        <button type="submit">Add Exam</button>
      </form>
    </div>
  );
};

export default AddExam;
