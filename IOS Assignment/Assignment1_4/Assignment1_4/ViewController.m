//
//  ViewController.m
//  Assignment1_4
//
//  Created by Subhradeep  on 3/18/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController
@synthesize viewArea,dotButton;
NSString *oprtr;
float result;

- (void)viewDidLoad {
    [super viewDidLoad];
    firstEntry = NULL;
    secondEntry = NULL;
    dotOperator = NULL;
    operatorPressed = FALSE;
}

- (IBAction)clearButton:(id)sender {
    self.viewArea.text = @"";
    firstEntry = NULL;
    secondEntry = NULL;
    operatorPressed = FALSE;
    dotButton.enabled = TRUE;
}

- (IBAction)equalsButton:(id)sender {
    if([oprtr isEqualToString:@"+"]) {
        result = [firstEntry floatValue] + [secondEntry floatValue];
    }
    else if([oprtr isEqualToString:@"-"]) {
        result = [firstEntry floatValue] - [secondEntry floatValue];
    }
    else if([oprtr isEqualToString:@"*"]) {
        result = [firstEntry floatValue] * [secondEntry floatValue];
    }
    else {
        result = [firstEntry floatValue] / [secondEntry floatValue];
    }
    
    if(dotOperator != NULL )
    {
        viewArea.text = [NSString stringWithFormat:@"%@%@%@ = %.02f",firstEntry,oprtr,secondEntry,result];
        
        firstEntry = [NSString stringWithFormat:@"%f",result];
        secondEntry = NULL;
    }
    else {
        viewArea.text = [NSString stringWithFormat:@"%@%@%@ = %ld",firstEntry,oprtr,secondEntry,(long)result];
        
        firstEntry = [NSString stringWithFormat:@"%ld",(long)result];
        secondEntry = NULL;
    }
}

- (IBAction)operatorPressed:(id)sender {
    operatorPressed = TRUE;
    if(firstEntry == NULL) {
        viewArea.text = @"First operand not found..";
        operatorPressed = FALSE;
    }
    else if(firstEntry != NULL) {
        oprtr = [sender currentTitle];
        dotButton.enabled = TRUE;
        viewArea.text = [NSString stringWithFormat:@"%@%@",firstEntry,oprtr];
    }
    else if(result != 0) {
        viewArea.text = [NSString stringWithFormat:@"%f%@",result,oprtr];
    }
}

- (IBAction)operandPressed:(id)sender {
    
    
    if([[sender currentTitle] isEqualToString:@"."]) {
        dotOperator = [sender currentTitle];
        if(operatorPressed == FALSE) {
            if(firstEntry == NULL) {
                firstEntry = [NSString  stringWithFormat:@"%d%@",0,[sender currentTitle]];
                viewArea.text = firstEntry;
            }
            else {
                firstEntry = [NSString stringWithFormat:@"%@%@",firstEntry,[sender currentTitle]];
                dotButton.enabled = FALSE;
                viewArea.text = firstEntry;
            }
        }
        else {
            if(firstEntry == NULL) {
                viewArea.text = @"First Operator Not Found;";
            }
            else {
                if(secondEntry == NULL) {
                    secondEntry = [NSString stringWithFormat:@"%d%@",0,[sender currentTitle]];
                    dotButton.enabled = FALSE;
                    viewArea.text = [NSString stringWithFormat:@"%@%@%@",firstEntry,oprtr,secondEntry];
                }
                else {
                    secondEntry = [NSString stringWithFormat:@"%@%@",secondEntry,[sender currentTitle]];
                    dotButton.enabled = FALSE;
                    viewArea.text = [NSString stringWithFormat:@"%@%@%@",firstEntry,oprtr,secondEntry];
                }
            }
        }
    }
    else {
        NSInteger op = [sender tag];
        if(operatorPressed == FALSE) {
            if(firstEntry == NULL) {
                firstEntry = [NSString  stringWithFormat:@"%ld",op];
                viewArea.text = firstEntry;
        }
        else {
            firstEntry = [NSString stringWithFormat:@"%@%ld",firstEntry,op];
            viewArea.text = firstEntry;
        }
    }
        else {
            if(firstEntry == NULL) {
                viewArea.text = @"First Operator Not Found;";
            }
            else {
                if(secondEntry == NULL) {
                    secondEntry = [NSString stringWithFormat:@"%ld",op];
                    viewArea.text = [NSString stringWithFormat:@"%@%@%@",firstEntry,oprtr,secondEntry];
                }
                else {
                    secondEntry = [NSString stringWithFormat:@"%@%ld",secondEntry,op];
                    viewArea.text = [NSString stringWithFormat:@"%@%@%@",firstEntry,oprtr,secondEntry];
                }
            }
        }
    }
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}
@end
