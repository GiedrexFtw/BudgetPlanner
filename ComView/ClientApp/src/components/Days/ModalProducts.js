import React, { useState } from "react";
import { Button, Modal } from "react-bootstrap";

export function ModalProducts( obj ) {
    const [showModal, setShowModal] = useState(false);
    let products =
        obj.day.products.length != 0 ?
            <div>
                <h2>Products bought on {obj.day.date.split('T')[0]}</h2>
            <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Amount</th>
                </tr>
            </thead>
            <tbody>
                {obj.day.products.map(product =>
                    <tr key={product.id}>
                        <td>{product.title}</td>
                        <td>{product.description}</td>
                        <td>{product.amount}</td>
                    </tr>
                )}
            </tbody>
                </table>
                <Button className="btn btn-danger" style={{textAlign: "center", float:"right"}} onClick={() => setShowModal(false) }>Close</Button>
            </div>
            : <p>There are no products linked to this day!</p>;
    return (
        <div key={obj.day.id}>
            <button
                className="btn btn-info"
                onClick={() => {
                    setShowModal(true);
                }}
            >
                <i class="fas fa-eye"></i>
            </button>
            <Modal onHide={() => setShowModal(false)} show={showModal}>
                { products}
            </Modal>
        </div>
    );
}