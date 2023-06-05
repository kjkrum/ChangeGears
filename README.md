# Change Gears
A console app that calculates thread pitches for the Mingxi MX-180 and similar mini lathes.

## Background
My MX-180 came with a set of change gears. I don't think I got all the gears I was supposed to, and I got a few duplicates. The threading chart on the gear cover is totally wrong, and the chart in the owner's manual calls for gears I don't have. I got tired of using an online calculator with greasy hands every time I wanted to cut threads, and I wasn't convinced that generic online calculators were giving me the best solutions.

## One gear?
In a simple gear train with one gear per shaft, only the gears on the spindle and lead screw matter. Since my lathe has a 40T gear on the spindle and a 2 mm lead screw pitch, the simplest solution to cut a 1 mm thread is just an 80T gear on the lead screw. The gears in between can be anything that fits. Likewise, the extra space in a 3-gear solution can be filled with anything.

## Customization
I run this program straight out of Visual Studio so I didn't bother with command line parameters. You'll need to edit the gear set at the top of the `Main` method to include the gears you actually have.

## Output
The output is CSV-formatted, pipe-delimited text. The metric and standard sections have independent columns and headers. Here's a standard solution:

    Gears|TPI|Error
    80,72,80,63,60|24|0.01%

This means the 80T and 72T are locked together on the first shaft. The 72T drives the 80T on the second shaft, which is locked to the 63T. Finally, the 63T drives the 60T on the lead screw. This cuts a 24 TPI thread with 0.01% accuracy.

Here's a metric solution:

    Gears|Pitch
    80,40,80|0.5

The 80T and 40T are locked together, with the 40T driving the 80T on the lead screw. This cuts a 0.5 mm thread.


## Side Note
I highly recommend getting a 63T gear. I got mine from from AliExpress for about $15 and modified it to fit my lathe. A 127T gear would produce perfect conversions between standard and metric, but they're hard to find, expensive, and probably too big for a small lathe. A 63T gear is a practical alternative and introduces an error of only 1/127 compared to a 127T. The 63T shows up in a lot of the best solutions for cutting standard threads on my metric lathe.