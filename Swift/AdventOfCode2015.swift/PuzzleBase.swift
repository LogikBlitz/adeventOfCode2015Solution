//
//  PuzzleBase.swift
//  AdventOfCode2015.swift
//
//  Created by Thomas Blitz on 18/12/15.
//  Copyright © 2015 TLogik. All rights reserved.
//

import Cocoa

class PuzzleBase: NSObject {

    private var delegate : PuzzleProtocol!
    internal override init() {
        
    }
    
    internal func setup(delegate:PuzzleProtocol) {
        self.delegate = delegate
    }
    
    internal func PrintPuzzleInfo(){
        print("Puzzle for CalenderDay: \(delegate.dayIndex) and Puzzle index: \(delegate.puzzleIndex)")
    }
    
}
