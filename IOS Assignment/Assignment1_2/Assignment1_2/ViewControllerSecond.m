//
//  ViewControllerSecond.m
//  Assignment1_2
//
//  Created by Subhradeep  on 3/15/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import "ViewControllerSecond.h"

@interface ViewControllerSecond ()
@end

@implementation ViewControllerSecond

-(void)viewDidLoad {
    [super viewDidLoad];
}

- (IBAction)goToFirstView:(UIButton *)sender {
//    UIStoryboard *myStoryBoard = [UIStoryboard storyboardWithName:@"Main" bundle:nil];
//    UIViewController *VC = [myStoryBoard instantiateViewControllerWithIdentifier:@"ViewController"];
//    [self presentViewController:VC animated:TRUE completion:nil];
    [self.navigationController popToRootViewControllerAnimated:YES];
}

- (IBAction)firstButtonClick:(id)sender
{
    self.radioButtonOne.selected = !self.radioButtonOne.isSelected;
    
    if (self.radioButtonOne.isSelected)
    {
        self.radioButtonTwo.selected = NO;
    }
    else{
        self.radioButtonOne.selected = YES;
    }
}

- (IBAction)secondButtonClick:(id)sender
{
    self.radioButtonTwo.selected = !self.radioButtonTwo.isSelected;
    
    if (self.radioButtonTwo.isSelected)
    {
        self.radioButtonOne.selected = NO;
    }
    else{
        self.radioButtonTwo.selected = YES;
    }
}

@end
