import React, { useState } from "react";
import { Button, Modal } from "react-bootstrap";

export function ModalDays(obj) {
    const [showModal, setShowModal] = useState(false);
    let days =
        obj.report.days.length != 0 ?
            <div>
                <h2>Days for report</h2>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Description</th>
                        </tr>
                    </thead>
                    <tbody>
                        {obj.report.days.map(day =>
                            <tr key={day.id}>
                                <td>{day.date}</td>
                                <td>{day.description}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
                <Button className="btn btn-danger" style={{ textAlign: "center", float: "right" }} onClick={() => setShowModal(false)}>Close</Button>
            </div>
            : <p>There are no days linked to this report!</p>;
    return (
        <div key={obj.report.id}>
            <button
                className="btn btn-info"
                onClick={() => {
                    setShowModal(true);
                }}
            >
                <i class="fas fa-eye"></i>
            </button>
            <Modal onHide={() => setShowModal(false)} show={showModal}>
                {days}
            </Modal>
        </div>
    );
}