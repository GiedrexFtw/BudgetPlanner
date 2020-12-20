import React, { Component } from 'react';
import {faFacebook, faTwitter, faGooglePlus, faLinkedin, faInstagram } from '@fortawesome/free-brands-svg-icons';
import '@fortawesome/free-regular-svg-icons';
import '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { library, dom } from "@fortawesome/fontawesome-svg-core";
import { Link } from 'react-router-dom';

dom.watch();

library.add(faFacebook, faTwitter, faGooglePlus, faLinkedin, faInstagram);


export class Footer extends Component {
    static displayName = Footer.name;

    render() {

        return (
            <footer className="page-footer font-small unique-color-dark" style={{ backgroundColor: "#c09f80" }}>
                <div style={{ backgroundColor: "#FEA365"}}>
                    <div className="container">
                        <div className="row py-4 d-flex align-items-center">
                            <div className="col-md-6 col-lg-5 text-center text-md-left mb-md-0">
                                <h6 className="mb-0">Share your expenses with friends on social media!</h6>
                            </div>
                            <div className="col-md-6 col-lg-7 text-center text-md-right">
                                <FontAwesomeIcon icon={faFacebook} className="mr-4" />
                                
                                <a className="tw-ic" >
                                    <i className="fab fa-twitter white-text mr-4"> </i>
                                </a>
                                <a className="gplus-ic" >    
                                    <i className="fab fa-google-plus white-text mr-4"> </i>
                                </a>
                                <a className="li-ic" >
                                    <i className="fab fa-linkedin white-text mr-4"> </i>
                                </a>
                                <a className="ins-ic">
                                    <i className="fab fa-instagram white-text"> </i>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="footer-info container-flex text-center  pt-3" style={{ backgroundColor: "#654321" }}>
                    <div className="row">
                        <div className="col-md-3 col-lg-4 col-xl-3 mx-auto mb-4">
                            <h6 className="text-uppercase font-weight-bold">Comview</h6>
                            <hr className="deep-purple accent-2 mb-4 mt-0 d-inline-block mx-auto" />
                            <img
                                alt="logo"
                                src="./logo.jpg"
                                width="200"
                                height="150"
                                className="d-inline-block align-top"
                            />{' '}
                            <p>Comview - your best budget measurement app!</p>

                        </div>
                        <div className="col-md-2 col-lg-2 col-xl-3 mx-auto mb-4">
                            <h6 className="text-uppercase font-weight-bold">Authentication</h6>
                            <hr className="deep-purple accent-2 mb-4 mt-0 d-inline-block mx-auto"  />
                            <p>
                                <Link tag={Link} className="text-light" to="/login">Login</Link>
                            </p>
                            <p>
                                -----
                            </p>
                            <p>
                                <Link tag={Link} className="text-light" to="/register">Register</Link>
                            </p>
                            <p>
                                --------
                            </p>

                        </div>

                        <div className="col-md-3 col-lg-2 col-xl-3 mx-auto mb-4">
                            <h6 className="text-uppercase font-weight-bold">Useful links</h6>
                            <hr className="deep-purple accent-2 mb-4 mt-0 d-inline-block mx-auto" />
                            <p>
                                <Link tag={Link} className="text-light" to="/categories">Categories</Link>
                            </p>
                            <p>
                                <Link tag={Link} className="text-light" to="/products">Products</Link>
                            </p>
                            <p>
                                <Link tag={Link} className="text-light" to="/days">Days</Link>
                            </p>
                            <p>
                                <Link tag={Link} className="text-light" to="/reports">Reports</Link>
                            </p>

                        </div>

                        <div className="col-md-4 col-lg-3 col-xl-3 mx-auto mb-md-0 mb-4">
                            <h6 className="text-uppercase font-weight-bold">Contact</h6>
                            <hr className="deep-purple accent-2 mb-4 mt-0 d-inline-block mx-auto"  />
                            <p>
                                <i className="fas fa-home mr-3"></i> Kaunas, Lithuania</p>
                            <p>
                                <i className="fas fa-envelope mr-3"></i> giedriusbackaitis@gmail.com</p>
                            <p>
                                <i className="fas fa-phone mr-3"></i> 861255100</p>
                            <p>
                                <i className="fas fa-print mr-3"></i> No fax yet</p>
                        </div>
                    </div>
                </div>
                <div className="footer-copyright text-center py-3" style={{ backgroundColor: "#2b1d0e", color: "white" }}>© 2020 Copyright:
                    <a href="#"> Comview</a>
                </div>
            </footer>
        );
    }
}
