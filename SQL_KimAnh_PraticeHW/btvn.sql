/* Ques 1 */
Select last_name, hire_date from employees 
where department_id in 
(select department_id from employees where last_name = 'Zlotkey') and last_name != 'Zlotkey';

Select e1.last_name, e1.hire_date from employees e1 join employees e2
on e1.department_id = e2.department_id
where e1.last_name != 'Zlotkey' and e2.last_name = 'Zlotkey';

/* Ques 2 */
Select employee_id, last_name, salary from employees
where salary > (select avg(salary) from employees)
order by salary ASC;

/* Ques 3 */
Select employee_id, last_name from employees 
where department_id in 
(select department_id from employees where last_name like '%u%');

/* Ques 4 */
Select last_name, e.department_id, job_id  
from employees e join departments d on d.department_id = e.department_id
where location_id = 1700;


/* Ques 5 */
Select last_name, salary from employees
where manager_id in (select employee_id from employees where last_name = 'King');

/* Ques 6 */
Select e.department_id, last_name, job_id 
from employees e join departments d on e.department_id = d.department_id
where department_name like '%Executive%'

/* Ques 7 */
Select employee_id, last_name, salary 
from employees e 
where salary > (select avg(salary) from employees) and e.department_id in 
(select department_id from employees where last_name like '%u%');

/* Ques 8 */
Select ROUND(max(salary),0) as Maximum, ROUND(min(salary),0) as Minimum, 
ROUND(sum(salary),0) as Sum, ROUND(Avg(salary),0) as Average from employees;

/* Ques 9 */
Select ((UPPER(substring(last_name,1,1)))+(LOWER(substring(last_name,2,LEN(last_name))))) as Last_name,
LEN(last_name) as Length_Name
from employees
Where (substring(last_name,1,1)) Like 'J' OR (substring(last_name,1,1)) Like 'A' OR (substring(last_name,1,1)) Like 'M'
Order by last_name ASC;

/* Ques 10 */
Select employee_id, last_name, salary, (salary + (salary * 15.5 / 100)) as New_Salary 
from employees ;

/* Ques 11 */
Select   last_name as Column1, CAST(department_id as varchar(50)) as Column2 from employees
union all
Select CAST(department_id as varchar(50)), department_name from departments;

/* Ques 12 */
Select e2.employee_id
from employees e1 join employees e2 on e1.employee_id = e2.manager_id
where e2.hire_date > e1.hire_date
union --no duplicate
Select e.employee_id
from employees e join departments d on e.department_id = d.department_id join locations l on d.location_id = l.location_id
where city like 'Toronto'