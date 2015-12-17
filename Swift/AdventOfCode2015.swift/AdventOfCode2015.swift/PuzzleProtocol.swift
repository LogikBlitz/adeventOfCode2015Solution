//
//  PuzzleProtocol.swift
//  AdventOfCode2015.swift
//
//  Created by Thomas Blitz on 15/12/15.
//  Copyright © 2015 TLogik. All rights reserved.
//

import Foundation

protocol PuzzleProtocol{
    func printPurpose();
    func printSolution();
    var dayIndex: Int { get }
    var puzzleIndex: Int { get }
    

}
