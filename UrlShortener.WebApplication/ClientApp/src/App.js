import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';
import UrlShortener from './UrlShortener';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div>
        <h1>URL Shortening App</h1>
        <UrlShortener />
      </div> 
    );
  }
}
