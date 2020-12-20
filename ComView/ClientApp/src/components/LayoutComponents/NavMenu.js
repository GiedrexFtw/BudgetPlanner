import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { Cookies } from 'react-cookie';
import './NavMenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true,
            jwt: null
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }
    componentDidMount() {
        let cookie = new Cookies();
        var token = cookie.get("access_token");
        console.log(token)
        this.setState({jwt: token })
    }

    render() {
        let jwt1 = this.state.jwt == null ? [<NavItem>
                                    <NavLink tag={Link} className="text-light" to="/login">Login</NavLink>
                                </NavItem>,
                                <NavItem>
                                    <NavLink tag={Link} className="text-light" to="/register">Register</NavLink>
                                </NavItem>]:<p></p> ;
        return (
            <header>
                <Navbar className="navbar-expand-md navbar-toggleable-md ng-white border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/" style={{fontSize:"20px"}}>
                        <img
                                alt="logo"
                                src="./logo.jpg"
                                width="50"
                                height="50"
                                className="d-inline-block align-top"
                            />{' '}
                            Comview
                            </NavbarBrand>
                        <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                        <Collapse className="d-md-inline-flex flex-md-row" isOpen={!this.state.collapsed} navbar>
                            <ul className="navbar-nav flex-grow">
                                <NavItem>
                                    <NavLink tag={Link} className="text-light" to="/products">Products</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-light" to="/days">Days</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} className="text-light" to="/reports">Reports</NavLink>
                                </NavItem>
                                {jwt1 }
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }
}
