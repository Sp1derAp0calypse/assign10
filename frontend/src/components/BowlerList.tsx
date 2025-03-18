import { useEffect, useState } from 'react'
import {bowler} from '../types/bowler'

function BowlerList () {

    const [bowlers, setBowlers] = useState<bowler[]>([]);

    useEffect(() => {
        const fetchBowler = async () => {
            const response = await fetch('https://localhost:5000/api/Bowling');
            const data = await response.json();
            setBowlers(data);
        };
        fetchBowler();
    }, []);
        

    return (
        <>
            <h1>Bowler List</h1>
            <table>
                <thead>
                <tr>
                    <th>Bowler Name</th>
                    <th>Team Name</th>
                    <th>Address</th>
                    <th>Phone Number</th>
                </tr>
                </thead>

                <tbody>
                    {
                        bowlers.map((b) => (
                            <tr key={b.bowlerId}>
                                <td>{b.firstName} {b.middleName} {b.lastName}</td>
                                <td>{b.teamName}</td>
                                <td>{b.address}, {b.city}, {b.state} {b.zip}</td>
                                <td>{b.phoneNumber}</td>
                            </tr>
                        ))
                    }
                </tbody>
            </table>
        </>
    )
}

export default BowlerList;