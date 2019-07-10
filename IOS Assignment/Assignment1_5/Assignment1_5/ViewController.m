//
//  ViewController.m
//  Assignment1_5
//
//  Created by Subhradeep  on 3/19/19.
//  Copyright © 2019 Subhradeep . All rights reserved.
//

#import "ViewController.h"
#import "CellViewCustom.h"

@interface ViewController () <UITableViewDataSource, UITableViewDelegate> {
    NSString *file;
    NSString *stringObject;
    NSArray *dataArray;
}

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    file = [[NSBundle mainBundle] pathForResource:@"countrylist" ofType:@"json"];
    stringObject = [[NSString alloc] initWithContentsOfFile:file encoding:NSUTF8StringEncoding error:NULL];
    NSError *error = nil;
    dataArray = [NSJSONSerialization JSONObjectWithData:[stringObject dataUsingEncoding:NSUTF8StringEncoding] options:kNilOptions error:&error];
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return dataArray.count;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return 1;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    static NSString *cellIndex = @"Cell";
    CellViewCustom *cell = [tableView dequeueReusableCellWithIdentifier:cellIndex];
    
    NSDictionary *dict = [dataArray objectAtIndex:indexPath.section];
    
    NSString *str = @"data:image/jpg;base64,";
    str = [str stringByAppendingString:[dict objectForKey:@"media"]];
    NSURL *url = [NSURL URLWithString:str];
    NSData *data = [NSData dataWithContentsOfURL:url];
    cell.showImage.image = [UIImage imageWithData:data];
    
    
    cell.nameLabel.text = [NSString stringWithFormat:@"%@ (%@)" , [dict objectForKey:@"name"], [dict objectForKey:@"countryCode"]];
    cell.stdCodeLabel.text = [NSString stringWithFormat:@"Phone Code:%@" ,[dict objectForKey:@"phoneCode"]];
    cell.currencyLabel.text = [NSString stringWithFormat:@"%@", [dict objectForKey:@"currencyCode"]];
    
    return cell;
}

@end
