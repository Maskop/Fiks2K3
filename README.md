**FIT Programming Correspondence Seminar**  
**Year 2024/25, Round 3**  

### **Task 2: Stars**  

**Answer Sfinx! (10 points)**  
This task is evaluated automatically. The output of the program must precisely match the output specification below.  
You can read how to submit this type of tasks on the FIKS website under the "How to solve FIKS" section.  

It's incredible how, whenever you want to take a picture, something moves, twists, flickers, or splits so that barely a hint of the scenery remains. You’ve long known that taking pictures from a rocket during launch is highly impractical, even though the view is stunning. But in space, you would expect nothing to move where it shouldn't. Even Newton said so, so it must be true.  

One day, as you looked out of the window and saw the stars looking more beautiful than ever, you felt a strong urge to capture the stunning view. You certainly didn’t expect that your camera would come loose from its arranged straps, take a picture at that exact moment, and then break immediately, preventing you from taking another shot. Now, all you have left are bits of plastic, glass, and a strangely captured image of the night sky... It’s as if every star appears twice. What an effect a long exposure can create! But were the stars actually captured twice, or did the sky just turn out strangely?  

Perhaps you could check whether they are centrally symmetric. But with thousands of stars in the picture, how could you possibly find the center among thousands of points?  

### **Input**  
The first line contains an integer **t** (1 ≤ t ≤ 100), followed by **t** test cases.  
Each test case starts with an integer **n** (2 ≤ n ≤ 10⁶).  
The next two lines contain **n** integers:  
- The first line contains coordinates **x₁, x₂, ..., xₙ**  
- The second line contains coordinates **y₁, y₂, ..., yₙ**  
(-10⁹ ≤ xᵢ, yᵢ ≤ 10⁹).  

It is guaranteed that no two stars have the same coordinates.  

### **Output**  
For each test case, output two numbers **xₛ yₛ** representing the coordinates of the center of symmetry.  
If no such center exists, output **ajajaj** instead.  

The answer will be considered "almost correct" if the coordinates differ by at most **10⁻⁶** either absolutely or relatively. An almost correct solution will be awarded 80% of the full points.  

#### **Example Input**  
```
2
4
0 0 1 1
0 1 0 1
5
5 2 0 -3 -7
3 7 0 -5 -2
```

#### **Example Output**  
```
0.5 0.5
ajajaj
```

[Link to FIKS website](https://fiks.fit.cvut.cz/about/how-to#Odpov%C4%9Bz%20Sfinze!)
