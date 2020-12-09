import React, { useState } from "react";
import { Modal } from "react-bootstrap";

export function ModalProducts( obj ) {
    const [showModal, setShowModal] = useState(false);
    let products =
        obj.day.products.length != 0 ? <table className='table table-striped' aria-labelledby="tabelLabel">
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
            : <p>There are no products linked to this day!</p>;
    return (
        <div key={obj.day.id}>
            <button
                className="btn btn-primary"
                onClick={() => {
                    setShowModal(true);
                }}
            >
                Show Products
            </button>
            <Modal onHide={() => setShowModal(false)} show={showModal}>
                { products}
            </Modal>
        </div>
    );
}