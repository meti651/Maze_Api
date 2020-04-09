using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maze_API.Models;
using MazeGenerator;
using MazeGenerator.Models;
using MazePathFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Maze_API.Controllers
{
    [Route("api/maze/generator")]
    [ApiController]
    public class MazeGeneratorController : ControllerBase
    {
        public ModelMazeGenerator MazeGenerator { get; set; }

        public MazeGeneratorController(ModelMazeGenerator mazeGenerator)
        {
            MazeGenerator = mazeGenerator;
        }

        [HttpGet("normal_row={row}&&column={column}")]
        public ActionResult GetNormalMaze(string row, string column)
        {
            List<string> errorList = new List<string>();
            int rowNum = 0, columnNum = 0;
            try
            {
                rowNum = Int32.Parse(row);
                columnNum = Int32.Parse(column);
            }
            catch(FormatException e)
            {
                errorList.Add($"Unable to parse '{row}' or '{column}'.");
            }
            
            if(rowNum != 0 && columnNum != 0)
            {
                MazeGenerator.GenerateNormalMaze(rowNum, columnNum);
                string jsonMaze = JsonConvert.SerializeObject(MazeGenerator.NormalMaze);
                return Ok(jsonMaze);
            }
            errorList.Add("The row or column must be greater than 0");
            return BadRequest(errorList);
        }

        [HttpGet("pathFinder_row={row}&&column={column}")]
        public ActionResult GetPathFindingMaze(string row, string column)
        {
            List<string> errorList = new List<string>();
            int rowNum = 0, columnNum = 0;
            try
            {
                rowNum = Int32.Parse(row);
                columnNum = Int32.Parse(column);
            }
            catch (FormatException e)
            {
                errorList.Add($"Unable to parse '{row}' or '{column}'.");
            }

            if (rowNum != 0 && columnNum != 0)
            {
                MazeGenerator.GeneratePathFindingMaze(rowNum, columnNum);
                string jsonMaze = JsonConvert.SerializeObject(MazeGenerator.PathFindingMaze);
                return Ok(jsonMaze);
            }
            errorList.Add("The row or column must be greater than 0");
            return BadRequest(errorList);
        }
    }
}