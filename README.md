# Eleven Fifty .NET 301 Completed Solution - ASP.NET MVC, WebAPI, and Xamarin.Forms

![Eleven Fifty Logo](https://eleven50.wpengine.com/wp-content/uploads/2017/03/Eleven-Fifty-Academy-Logo-1.png)

This project represents the complete codebase for our Advanced .NET course. Students use this project in the .NET cohort to continue exploring the .NET Framework from an API and mobile development perspective.

Prior to working with this code, students learn ASP.NET MVC in the .NET 201 course.

To learn more about Eleven Fifty Academy, a non-for-profit coding academy, visit https://elevenfifty.org.

# Project Legend

Here's what each project does and why it does it:

## ElevenNote.Web

The ASP.NET MVC web presentation tier for creating, updating, deleting, listing, and retrieving notes.

## ElevenNote.API

The ASP.NET WebAPI presentation tier for creating, updating, deleting, listing, and retrieving notes.

## ElevenNoteMobileApp

The Xamarin.Forms Android and iOS presentation tier for creating, updating, deleting, listing, and retrieving notes.

## ElevenNote.Models

The shared models for all presentation tiers.

## ElevenNote.Services

The shared service for all note CRUD actions, used by the Web and API projects. Interacts with the database.

## ElevenNote.Data

The database context used by the Web and API projects. By default, uses a SQL LocalDB instance. When deployed, we use an Azure SQL instance.
