//
//  Puzzle1.swift
//  AdventOfCode2015.swift
//
//  Created by Thomas Blitz on 15/12/15.
//  Copyright © 2015 TLogik. All rights reserved.
//

import Foundation

class Puzzle1:PuzzleBase, PuzzleProtocol {
    
    internal override init() {
        super.init()
        super.setup(self)
    }
    
    var dayIndex: Int {return 1}
    var puzzleIndex: Int { return 1}
    
    func printPurpose(){
        super.PrintPuzzleInfo()
        print("To what floor do the instructions take Santa?")
    }
    func printSolution(){
        print("The level is: \(GetFloor(PuzzleInput.Data))")
    }
    
    private func GetFloor(input:String)-> Int{
        var count = 0
        for char in input.characters{
            
            switch(char){
            case "(":
                count++
                break
                
            case  ")":
                count--
                break
            default:
                break
            }
            
        }
        return count;
    }
    
}