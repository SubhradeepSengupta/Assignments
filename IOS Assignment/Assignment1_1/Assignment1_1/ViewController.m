//
//  ViewController.m
//  Assignment1_1
//
//  Created by Subhradeep  on 3/14/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController

@synthesize inputText,labelText;

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (IBAction)actionButton:(id)sender {
    NSString *inputString = inputText.text;
    
    labelText.text = inputString;
}
@end
