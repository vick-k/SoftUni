function printEmployees(employees) {
    let allEmployees = [];

    employees.forEach(employee => {
        const newEmployee = {
            name: employee,
            personalNumber: employee.length,
        };

        allEmployees.push(newEmployee);
    });

    allEmployees.forEach(employee =>
        console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`)
    );
}

printEmployees(['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal']);
