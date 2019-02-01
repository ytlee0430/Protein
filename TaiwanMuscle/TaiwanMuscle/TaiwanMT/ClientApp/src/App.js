import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { AboutUs } from './components/AboutUs';
import { Contact } from './components/Contact';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/AboutUs' component={AboutUs} />
        <Route path='/fetchdata' component={FetchData} />
        <Route path='/Contact' component={Contact} />
      </Layout>
    );
  }
}
