import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import { NavMenu } from './NavMenu';

export class Layout extends Component {
  displayName = Layout.name

  render() {
    return (
      <Grid fluid>
        <Row>
          <Col sm={12} className="navBarCol">
            <NavMenu />
          </Col>
          <Col sm={12} className="contentCol">
            {this.props.children}
          </Col>
        </Row>
      </Grid>
    );
  }
}
