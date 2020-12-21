using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminLte3.Models;
using AdminLte3.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;

namespace AdminLte3.Controllers
{
    public class TaskController : Controller
    {
        //private readonly IMapper _mapper;

        private readonly AdminLte3.Data.TodosContext _context;
        public TaskController(AdminLte3.Data.TodosContext context)
        {
            //_mapper = mapper;
            _context = context;
        }

        public IActionResult Index ()
        {
            return View();
        }
        [HttpGet]
        public SelectList GetTodoTypes()
        {
            var enumList = (from Enum e in Enum.GetValues(typeof(TodoType))
                            select new
                            {
                                Name = e,
                                Id = Convert.ToInt32(e).ToString()
                            }).ToList();
            return new SelectList((IEnumerable)enumList, "Id", "Name");
        }
        [HttpPost]
        public IActionResult GetTasks(TodoType filter)
        {
            var todos = _context.Todos.ToList();
            if (filter == 0)
            {
                return Json(todos);
            }
            else
            {
                var todosWithSpecificTodoType = todos.Where(todo => todo.TodoType == filter).ToList();

                //todos = todos.FindAll(todo => todo.TodoType = filter);
                //foreach (TodoType filter in Enum.GetValues(typeof(Days)))
                //{
                //var model = todos.Where(todo => todo.TodoType == filter).ToList();
                //}
                return Json(todosWithSpecificTodoType);
            }
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var todos = _context.Employees.ToList();
            return Json(todos);
        }
        [HttpPost]
        public IActionResult AddTodo(string Title, TodoType TodoType, Boolean IsUrgent, Boolean HasReminder, DateTime ReminderTime, Boolean teamWork, Boolean HasExplanation, string Explanation)
        {
            if (ModelState.IsValid)
            {
                var emptyTodo = new Todo()
                {
                    Title = Title,
                    TodoType = TodoType,
                    IsUrgent = IsUrgent,
                    HasReminder = HasReminder,
                    ReminderTime = ReminderTime,
                    Teamwork = teamWork,
                    HasExplanation = HasExplanation,
                    Explanation = Explanation
                };

                _context.Todos.Add(emptyTodo);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Task");
        }

        [HttpPost]
        public IActionResult EditTodo(int TodoID, string Title, TodoType TodoType, Boolean HasReminder, Boolean IsUrgent, DateTime ReminderTime, Boolean Teamwork, Boolean HasExplanation, string Explanation)
        {
            if (ModelState.IsValid)
            {
                var TodoToUpdate = _context.Todos.Find(TodoID);
                TodoToUpdate.Title = Title;
                TodoToUpdate.TodoType = TodoType;
                TodoToUpdate.IsUrgent = IsUrgent;
                TodoToUpdate.HasReminder = HasReminder;
                TodoToUpdate.ReminderTime = ReminderTime;
                TodoToUpdate.Teamwork = Teamwork;
                TodoToUpdate.HasExplanation = HasExplanation;
                TodoToUpdate.Explanation = Explanation;

                _context.Todos.Update(TodoToUpdate);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Task");
        }

        [HttpPost]
        public IActionResult ChangeTodoStatus(int TodoID, TodoStatus TodoStatus)
        {
            var TodoToUpdateStatus = _context.Todos.Find(TodoID);
            TodoToUpdateStatus.TodoStatus = TodoStatus;
            _context.Todos.Update(TodoToUpdateStatus);
            _context.SaveChanges();
            return RedirectToAction("Index", "Task");
        }

        [HttpPost]
        public IActionResult ViewTodo(int id)
        {
            var TodoToView = _context.Todos.Find(id);
            return Json(TodoToView);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTodo(int? TodoID)
        {
            var TodoToDelete = await _context.Todos.FindAsync(TodoID);
            if (TodoToDelete == null)
            {
                return Json(false);
            }
            try
            {
                _context.Todos.Remove(TodoToDelete);
                var result = await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Task");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return Json(false);
            }
        }
    }
}
